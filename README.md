
Example implementation of querying against date and other parameters.


Return everything
```
https://localhost:5001/api/books
```

**Query string return 2 results**
```
https://localhost:5001/api/books?searchQuery=heller
```

**Query string with pagination argument (rpp = records per page)**
Returns 1 page 
```
https://localhost:5001/api/books?searchQuery=heller&rpp=1
```
The above query returns these headers:

```
{"totalRecords":2,"rpp":1,"currentPage":1,"totalPages":2,"previousPageLink":null,"nextPageLink":"https://localhost:5001/api/books?searchQuery=heller&page=2&rpp=1"}
```

**Query string with date parameters to filter between two dates**
```
https://localhost:5001/api/books?dateModified={gt:'2020-01-01', lt:'2021-03-25'}
```

**Query string with date parameter to filter greater than date only**
```
https://localhost:5001/api/books?dateModified={gt:'2020-01-01'}
```

