// // --------------------------------------------------------------------------------------------------------------------
// // <copyright company="Ascensio System Limited" file="Configure.cs">
// //   
// // </copyright>
// // <summary>
// //   (c) Copyright Ascensio System Limited 2008-2012
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

#region using

using ASC.Xmpp.Core.protocol.x.data;

#endregion

namespace ASC.Xmpp.Core.protocol.extensions.pubsub
{
    public class Configure : PubSubAction
    {
        #region << Constructors >>

        public Configure()
        {
            TagName = "configure";
        }

        public Configure(string node) : this()
        {
            Node = node;
        }

        public Configure(Type type) : this()
        {
            Type = type;
        }

        public Configure(string node, Type type) : this(node)
        {
            Type = type;
        }

        #endregion

        public Access Access
        {
            get { return (Access) GetAttributeEnum("access", typeof (Access)); }
            set
            {
                if (value == Access.NONE)
                    RemoveAttribute("access");
                else
                    SetAttribute("access", value.ToString());
            }
        }

        /// <summary>
        ///   The x-Data Element
        /// </summary>
        public Data Data
        {
            get { return SelectSingleElement(typeof (Data)) as Data; }
            set
            {
                if (HasTag(typeof (Data)))
                    RemoveTag(typeof (Data));

                if (value != null)
                    AddChild(value);
            }
        }
    }
}