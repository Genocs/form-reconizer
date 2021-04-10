﻿namespace Genocs.Integration.MSAzure.Options
{
    public class AzureStorageConfig
    {
        public string AccountName { get; set; }
        public string AccountKey { get; set; }
        public string UploadContainer { get; set; }
        public string TrainingSetContainerUrl { get; set; }
        public string ThumbnailContainer { get; set; }        
        public string InspectingFileUrl { get; set; }
    }
}
