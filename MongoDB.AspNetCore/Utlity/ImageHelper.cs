using System;

namespace MongoDB.AspNetCore.Utlity
{
    public  class ImageHelper
    {
        public static byte[] GetImage(string images)
        {
            byte[] bytes= null;
            if (!string.IsNullOrEmpty(images))
            {
                bytes = Convert.FromBase64String(images);
            }
            return bytes;
        }
    }
}
