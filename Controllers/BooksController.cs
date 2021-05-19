using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using RMQueryDemo.Helpers;
using RMQueryDemo.Models;
using RMQueryDemo.Parameters;
using RMQueryDemo.Services.Interfaces;

namespace RMQueryDemo.Controllers
{
    
    [Route("api/books")]
    public class BooksController : ControllerBaseWithResourceUri
    {

        readonly IBooksService _booksService;

        public BooksController(IBooksService booksService, LinkGenerator linkGenerator) : base(linkGenerator)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public ActionResult GetBooks(BooksParameters parameters)
        {
            var results = _booksService.GetBooks(parameters);
            this.AddPaginationHeaders(results, parameters, "GetBooks");
            return Ok(results);
        }
    }
}
