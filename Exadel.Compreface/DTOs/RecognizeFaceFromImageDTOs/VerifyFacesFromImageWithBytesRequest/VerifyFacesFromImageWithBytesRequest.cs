﻿using Exadel.Compreface.DTOs.RecognitionDTOs.BaseRequests;

namespace Exadel.Compreface.DTOs.RecognizeFaceFromImageDTOs.VerifyFacesFromImageWithBytesRequest
{
    public class VerifyFacesFromImageWithBytesRequest : BaseVerifyFacesFromImageRequest
    {
        public byte[] Bytes { get; set; }
    }
}