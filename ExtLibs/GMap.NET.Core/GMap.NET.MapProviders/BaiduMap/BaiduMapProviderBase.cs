namespace GMap.NET.MapProviders
{
    using GMap.NET;
    using GMap.NET.Projections;
    using System;

    public abstract class BaiduMapProviderBase : GMapProvider
    {
        public BaiduMapProviderBase()
        {
            MaxZoom = null;
            RefererUrl = "http://map.baidu.com";
            Copyright = string.Format("©{0} Baidu Corporation, ©{0} NAVTEQ, ©{0} Image courtesy of NASA", DateTime.Today.Year);
        }

        public override PureProjection Projection
        {
            get { return MercatorProjection.Instance; }
        }

        GMapProvider[] overlays;
        public override GMapProvider[] Overlays
        {
            get
            {
                if (overlays == null)
                {
                    overlays = new GMapProvider[] { this };
                }
                return overlays;
            }
        }
    }
}
