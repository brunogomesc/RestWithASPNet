using Microsoft.AspNetCore.Http;
using RestWithASPNet.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNet.Business
{
    public interface IFileBusiness
    {

        public byte[] GetFile(string filename);

        public Task<FileDetailVO> SaveFileToDisk(IFormFile file);

        public Task<List<FileDetailVO>> SaveFilesToDisk(IList<IFormFile> files);

    }
}
