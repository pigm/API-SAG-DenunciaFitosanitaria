namespace Denuncia.Presentacion.MVC.Web.Models
{
    public class JsTreeModel
    {
        public int id { get; set; }
        public string parent { get; set; }
        public string icon { get; set; }
        public string text { get; set; }
        public JsTreeStateModel state { get; set; }

        public JsTreeModel(int id, string parent, string text, string icon) : this(id, parent, text, icon, false, false)
        {
        }
        public JsTreeModel(int id, string parent, string text, string icon, bool selected, bool disabled)
        {
            this.id = id;
            this.parent = parent;
            this.text = text;
            this.icon = icon;
            this.state = new JsTreeStateModel() { opened = false, selected = selected, disabled = disabled };
        }
    }

    public class JsTreeStateModel
    {
        public bool opened { get; set; }
        public bool selected { get; set; }
        public bool disabled { get; set; }
    }
}