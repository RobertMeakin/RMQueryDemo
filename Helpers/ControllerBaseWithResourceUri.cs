using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RMQueryDemo.Parameters;

namespace RMQueryDemo.Helpers
{
    public class ControllerBaseWithResourceUri : ControllerBase
    {
        private readonly LinkGenerator _linkGenerator;

        public ControllerBaseWithResourceUri(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }

        internal string CreateResourceUri(IParametersBase parameters, ResourceUriType type, string routeName)
        {

            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return _linkGenerator.GetUriByAction(
                        HttpContext,
                        routeName,
                        values: new
                        {
                            searchQuery = parameters.SearchQuery,
                            page = parameters.Page - 1,
                            parameters.rpp
                        });

                case ResourceUriType.NextPage:
                    return _linkGenerator.GetUriByAction(
                        HttpContext,
                        routeName, values: new
                        {
                            searchQuery = parameters.SearchQuery,
                            page = parameters.Page + 1,
                            parameters.rpp
                        });

                default:
                    return _linkGenerator.GetUriByAction(
                        HttpContext,
                        routeName,
                        values: new
                        {
                            searchQuery = parameters.SearchQuery,
                            page = parameters.Page,
                            parameters.rpp
                        });
            }
        }

        internal void AddPaginationHeaders<T>(PagedList<T> pagedList, IParametersBase parameters, string routeName)
        {

            var previousPageLink = pagedList.HasPrevious ? CreateResourceUri(parameters, ResourceUriType.PreviousPage, routeName) : null;
            var nextPageLink = pagedList.HasNext ? CreateResourceUri(parameters, ResourceUriType.NextPage, routeName) : null;
            var paginationMetadata = new PaginationMetadata
            {
                TotalRecords = pagedList.TotalCount,
                Rpp = pagedList.Rpp,
                CurrentPage = pagedList.CurrentPage,
                TotalPages = pagedList.TotalPages,
                PreviousPageLink = previousPageLink,
                NextPageLink = nextPageLink
            };

            Response.Headers.Add("Access-Control-Expose-Headers", "X-Pagination");
            var paginationMetadataSerialised = JsonConvert.SerializeObject(paginationMetadata, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetadata));
        }

    }
}