using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TddIntroduction
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void EmptyTemplate()
        {
            var template = new Template("");
            Assert.AreEqual("", template.Render());
        }

        [Test]
        public void TemplateWithNoPlaceHolders()
        {
            var template = new Template("Hello there");
            Assert.AreEqual("Hello there", template.Render());
        }

        [Test]
        public void TemplateWithAnotherOnePlaceHolders()
        {
            var template = new Template("Hello {name}");
            var placeHolders = new List<PlaceHolder>();
            placeHolders.Add(new PlaceHolder("name", "Cash"));
            Assert.AreEqual("Hello Cash", template.Render(placeHolders));
        }

        [Test]
        public void TemplateWithTwoPlaceHolders()
        {
            var template = new Template("Hello {firstname} {lastname}");
            var placeHolders = new List<PlaceHolder>();
            placeHolders.Add(new PlaceHolder("firstname", "Cash"));
            placeHolders.Add(new PlaceHolder("lastname", "Wu"));
            Assert.AreEqual("Hello Cash Wu", template.Render(placeHolders));
        }

        [Test]
        public void X()
        {
            var template = new Template("Hello {name}");
            var placeHolders = new PlaceHolders();
            placeHolders.Add("name", "cash");

            Assert.AreEqual("Hello Cash", template.Render(placeHolders));
        }
    }

    public class PlaceHolders : List<PlaceHolder>
    {
        internal void Add(string v1, string v2)
        {
            throw new NotImplementedException();
        }
    }

    public class PlaceHolder
    {
        public string Key { get; }
        public string Value { get; }

        public PlaceHolder(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }

    public class Template
    {
        private readonly string template;

        public Template(string template)
        {
            this.template = template;
        }

        public string Render()
        {
            return template;
        }

        internal string Render(List<PlaceHolder> placeHolders)
        {
            var result = template;
            foreach (var placeHolder in placeHolders)
            {
                result = result.Replace("{" + placeHolder.Key + "}", placeHolder.Value);
            }

            return result;
        }
    }
}
