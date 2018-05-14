using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets11
{
    [AttributeUsage(AttributeTargets.All , AllowMultiple = false , Inherited = true)]
    public class InvokeOnKeyPressAttribute : Attribute
    {
        public KeyCode KeyCode { get; set; }
    }
}
