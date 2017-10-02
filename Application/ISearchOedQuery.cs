using System;
using System.Security.Cryptography.X509Certificates;

namespace Application
{
    public interface ISearchOedQuery
    {
        OedSearchResultsModel Execute(OedSearchResultsModel model);
    }
}
