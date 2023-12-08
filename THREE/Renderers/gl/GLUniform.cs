﻿using OpenTK.Graphics.ES30;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace THREE
{
    [Serializable]
    public class GLUniform : Hashtable
    { //TODO: Hashtable --> Dictionary<string,object>
        public string Id;

        public int Addr;

        public string UniformKind;

        public ActiveUniformType UniformType;

        public List<object> Cache = new List<object>();

        public GLUniform()
        {
        }

        public GLUniform Copy(GLUniform source)
        {
            var target = new GLUniform();

            target.Id = source.Id;
            target.Addr = source.Addr;
            target.UniformType = source.UniformType;
            target.Cache = source.Cache.GetRange(0, source.Cache.Count);

            foreach (DictionaryEntry entry in this)
            {
                target.Add(entry.Key, entry.Value);
            }

            return target;
        }
        public GLUniform(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }


}
