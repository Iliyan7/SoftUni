using WebServer.Enums;

namespace WebServer.Http.Response
{
    public class FileResponse : HttpResponse
    {
        public FileResponse(HttpStatusCode statusCode, byte[] fileData, string contentType)
        {
            this.FileData = fileData;
            this.StatusCode = statusCode;

            this.Headers.Add(HttpHeader.ContentLength, this.FileData.Length.ToString());
            this.Headers.Add(HttpHeader.ContentDisposition, "attachment");
            this.Headers.Add(HttpHeader.ContentType, contentType);
        }

        public byte[] FileData { get; }
    }
}
