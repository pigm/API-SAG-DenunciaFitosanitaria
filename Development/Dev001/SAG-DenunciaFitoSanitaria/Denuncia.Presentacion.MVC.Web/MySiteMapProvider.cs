using Denuncia.Entidad;
using Denuncia.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Denuncia.Presentacion.MVC.Web
{
    public class MySiteMapProvider : StaticSiteMapProvider
    {
        #region Members 
        private readonly object _siteMapLock = new object();
        private SiteMapNode _siteMapRoot;
        #endregion

        public override SiteMapNode BuildSiteMap()
        {
            lock (_siteMapLock)
            {
                if (_siteMapRoot != null)
                {
                    this.EnableLocalization = true;
                    return _siteMapRoot;
                }
                // Fill  SiteMapCollection from SQL table 
                base.Clear();
                CreateSiteMapRoot();
                return _siteMapRoot;
            }
        }

        void BuildTreeNode(WebSiteMap startingItem, IEnumerable<WebSiteMap> tobind, SiteMapNode node)
        {
            foreach (var item in tobind.Where(i => i.ParentID == startingItem.ID).OrderBy(x => x.SortID))
            {
                var explicitResourceKeys = new System.Collections.Specialized.NameValueCollection();
                if (!string.IsNullOrWhiteSpace(item.ResourceKey))
                {
                    explicitResourceKeys.Add("Title", "Menu");
                    explicitResourceKeys.Add("Title", item.ResourceKey);
                }
                var NodeToAdd = new SiteMapNode(this, item.ID.ToString(), item.url, item.Description, item.Description, null, null, explicitResourceKeys, null);

                AddNode(NodeToAdd, node);
                BuildTreeNode(item, tobind, NodeToAdd);
            }
        }

        protected override SiteMapNode GetRootNodeCore()
        {
            return BuildSiteMap();
        }

        #region Methods 

        private void CreateSiteMapRoot()
        {
            var siteMaps = new WebSiteMapServicio().ListaMenu();
            var parentNode = siteMaps.Where(x => x.ParentID == 0).FirstOrDefault();
            var explicitResourceKeys = new System.Collections.Specialized.NameValueCollection();
            explicitResourceKeys.Add("Title", "Menu");
            explicitResourceKeys.Add("Title", parentNode.ResourceKey);
            _siteMapRoot = new SiteMapNode(this, parentNode.ID.ToString(), parentNode.url, parentNode.Description, parentNode.Description, null, null, explicitResourceKeys, null);
            BuildTreeNode(parentNode, siteMaps, _siteMapRoot);
            AddNode(_siteMapRoot);
        }
        #endregion
    }
} 