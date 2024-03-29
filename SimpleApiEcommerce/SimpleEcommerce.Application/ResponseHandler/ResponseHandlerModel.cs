﻿namespace SimpleEcommerce.Application.ResponseHandler
{
    public class ResponseHandlerModel
    {
        public ResponseModel<T> Deleted<T>()
        {
            return new ResponseModel<T>()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = "Deleted"
                //Message = _stringLocalizer[SharedSesourcesKeys.Deleted]
            };
        }

        public ResponseModel<T> Success<T>(T entity, object Meta = null)
        {
            return new ResponseModel<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.OK,
                Succeeded = true,
                Message = "Success",
                //Message = _stringLocalizer[SharedSesourcesKeys.Done],
                Meta = Meta
            };
        }

        public ResponseModel<T> Unauthorized<T>()
        {
            return new ResponseModel<T>()
            {
                StatusCode = System.Net.HttpStatusCode.Unauthorized,
                Succeeded = true,
                Message = "Unauthorized"
                //Message = _stringLocalizer[SharedSesourcesKeys.UnAuthrize]
            };
        }

        public ResponseModel<T> BadRequest<T>(string Message = null)
        {
            return new ResponseModel<T>()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                Succeeded = false,
                Errors = Message.Split(',').ToList(),
                Message = Message ?? "BadRequest",
                //Message = _stringLocalizer[SharedSesourcesKeys.BadRequest],
            };
        }

        public ResponseModel<T> NotFound<T>(string message = null)
        {
            return new ResponseModel<T>()
            {
                StatusCode = System.Net.HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message == null ? "NotFound"/* _stringLocalizer[SharedSesourcesKeys.NotFound]*/ : message
            };
        }

        public ResponseModel<T> Created<T>(T entity, object Meta = null)
        {
            return new ResponseModel<T>()
            {
                Data = entity,
                StatusCode = System.Net.HttpStatusCode.Created,
                Succeeded = true,
                Message = "Created",
                //Message = _stringLocalizer[SharedSesourcesKeys.Created],
                Meta = Meta
            };
        }
    }
}