using System;
using System.Collections.Generic;

namespace GT.Persistance.Domain.Models
{
    public partial class XinfImage
    {
        public double InstanceKey { get; set; }
        public double? ImageNo { get; set; }
        public DateTime? ImageDttm { get; set; }
        public string ImageType { get; set; }
        public string ImageInfo { get; set; }
        public string ImageInfoEx { get; set; }
        public string RegionCalibration { get; set; }
        public double? AcqNo { get; set; }
        public DateTime? AcqDttm { get; set; }
        public double? WindowCenter { get; set; }
        public double? WindowWidth { get; set; }
        public char? WindowType { get; set; }
        public double? Curvature { get; set; }
        public double? State { get; set; }
        public double? Rotation { get; set; }
        public double? PixelsizeX { get; set; }
        public double? PixelsizeY { get; set; }
        public double? FrameWidth { get; set; }
        public double? FrameHeight { get; set; }
        public double? SamplesPerPixel { get; set; }
        public double? BitsAllocated { get; set; }
        public double? BitsStored { get; set; }
        public double? PhotometricInterpretation { get; set; }
        public double? PlanarConfiguration { get; set; }
        public double? PixelRepresentation { get; set; }
        public string PixelAspectRatio { get; set; }
        public string HeaderPostProcessing { get; set; }
        public string PlateId { get; set; }
        public string VideoInfo { get; set; }
        public string CassetteSize { get; set; }
    }
}
