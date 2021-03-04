using System;

namespace design_patterns_udemy.Builder.NormalBuilder
{
    // Concrete builder 
    public class HtmlBuilder
    {
        private readonly string rootName;
        HtmlElement root = new HtmlElement();

        public HtmlBuilder(string rootName)
        {
            this.rootName = rootName;
            root.Name = rootName;
        }

        // Adding Fluent Builder
        public HtmlBuilder AddChild(string childName, string childText){
            var e = new HtmlElement(childName, childText);
            root.Elements.Add(e);
            return this;
        }

        public override string ToString()
        {
            return root.ToString();
        }

        // our builder is statefull - we need the clear
        public void Clear(){
            root = new HtmlElement { Name = rootName };
        }
    }
}
