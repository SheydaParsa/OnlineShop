//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace PublicTools.Extensions
//{
//    public static class HttpFileTools
//    {
//     //   #region [- GetPath() -]
//        //public static string GetPath(string fileNameWithExtension, string root = "~",
//        //bool includeYearInPath = false, bool includeMonthInPath = false,
//        //bool includeDayInPath = false, string objectId = null,
//        //string urlPrefix = null, string fileNamePrefix = null)
//        //{
//        //#region Create Directory Address
//        //var persianDate = PersianDateTime.Now;
//        //var path = string.Join("/", root);
//        //if (includeYearInPath) path += "/" + persianDate.Year;
//        //if (includeMonthInPath) path += "/" + persianDate.Month;
//        //if (includeDayInPath) path += "/" + persianDate.Day;
//        //path += (objectId == null ? string.Empty : ("/" + objectId));
//        //var directoryAddress = Path.Combine(Directory.GetCurrentDirectory(), urlPrefix ?? "", "wwwroot", path.Replace("/", "\\"));
//        //#endregion

//        //#region Create File Name
//        //var trustedFileName = WebUtility.HtmlEncode(fileNameWithExtension);
//        //var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(trustedFileName);
//        //var fileName = fileNamePrefix != null ? fileNamePrefix + "_" : string.Empty;
//        //fileName += fileNameWithoutExtension + "_" + persianDate.Ticks.ToString() + Path.GetExtension(trustedFileName);
//        //#endregion

//        //if (!FileOperation.CreateDirectory(directoryAddress)) return null;
//        //return "wwwroot/" + path + "/" + fileName;
//        //} 
//        #endregion

//        #region [- GetRootPath() -]
//        public static string GetRootPath(bool withWwwRoot = true)
//        {
//            if (withWwwRoot)
//                return $"{Directory.GetCurrentDirectory()}\\wwwroot\\";

//            return $"{Directory.GetCurrentDirectory()}";
//        }
//        #endregion

//        #region [- Save(IFormFile file, string fullPath) -]
//        public static string Save(IFormFile file, string fullPath)
//        {
//            if (file != null && file.Length > 0)
//            {
//                using (var stream = new FileStream(fullPath, FileMode.Create))
//                {
//                    file.CopyTo(stream);
//                }
//                if (File.Exists(fullPath)) return fullPath.Contains("wwwroot/") ? fullPath.Remove(0, 8) : fullPath;
//            }

//            return null;
//        }
//        #endregion

//        #region [- Save(byte[] fileBytes, string fullPath) -]
//        public static string Save(byte[] fileBytes, string fullPath)
//        {
//            if (fileBytes != null && fileBytes.Length > 0)
//            {
//                var file = new FormFile(null, 0, fileBytes.Length, "", "");

//                using (var stream = new FileStream(fullPath, FileMode.Create))
//                {
//                    file.CopyTo(stream);
//                }
//                if (File.Exists(fullPath)) return fullPath;
//            }

//            return null;
//        }
//        #endregion

//        #region [- Read(string fullPath) -]
//        public static byte[] Read(string fullPath)
//        {
//            if (File.Exists(fullPath))
//                return File.ReadAllBytes(fullPath);

//            return null;
//        }
//        #endregion
//    }
//}
