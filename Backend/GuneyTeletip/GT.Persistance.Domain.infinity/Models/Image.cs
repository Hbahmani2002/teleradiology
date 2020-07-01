using System;
using System.Collections.Generic;


namespace GT.Persistance.Domain.infinity.Models
{
    public partial class Image
    {
        public decimal InstanceKey { get; set; }
        public decimal? ImageNo { get; set; }
        public DateTime? ImageDttm { get; set; }
        public string ImageType { get; set; }
        public string ImageInfo { get; set; }
        public string ImageInfoEx { get; set; }
        public string RegionCalibration { get; set; }
        public decimal? AcqNo { get; set; }
        public DateTime? AcqDttm { get; set; }
        public decimal? WindowCenter { get; set; }
        public decimal? WindowWidth { get; set; }
        public string WindowType { get; set; }
        public decimal? Curvature { get; set; }
        public decimal? State { get; set; }
        public decimal? Rotation { get; set; }
        public decimal? PixelsizeX { get; set; }
        public decimal? PixelsizeY { get; set; }
        public decimal? FrameWidth { get; set; }
        public decimal? FrameHeight { get; set; }
        public decimal? SamplesPerPixel { get; set; }
        public decimal? BitsAllocated { get; set; }
        public decimal? BitsStored { get; set; }
        public decimal? PhotometricInterpretation { get; set; }
        public decimal? PlanarConfiguration { get; set; }
        public decimal? PixelRepresentation { get; set; }
        public string PixelAspectRatio { get; set; }
        public string HeaderPostProcessing { get; set; }
        public string PlateId { get; set; }
        public string AnnotationLob { get; set; }
        public string PresentationStat { get; set; }
        public string VideoInfo { get; set; }
        public string CassetteSize { get; set; }
    }
}
