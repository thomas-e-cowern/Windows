using LibraryData;
using LibraryData.Models;
using System;
using System.Collections.Generic;

namespace LibraryServices
{
    public class LibraryAssetService : ILibraryAsset
    {
        private LibraryContext _context;
        public void Add(LibraryAsset newAsset)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LibraryAsset> GetAll()
        {
            throw new NotImplementedException();
        }

        public string GetAuthorOrDirector(int id)
        {
            throw new NotImplementedException();
        }

        public LibraryAsset GetById(int id)
        {
            throw new NotImplementedException();
        }

        public LibraryBranch GetCurrentLocation(int id)
        {
            throw new NotImplementedException();
        }

        public string GetDeweyIndex(int id)
        {
            throw new NotImplementedException();
        }

        public string GetIsbn(int id)
        {
            throw new NotImplementedException();
        }

        public string GetTitle(int id)
        {
            throw new NotImplementedException();
        }

        public string GetType(int id)
        {
            throw new NotImplementedException();
        }
    }
}
