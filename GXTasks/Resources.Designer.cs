//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GXTasks {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("GXTasks.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Not that we are doing too much work, but, oh well....
        /// </summary>
        public static string AdditionalAndImportantInfo {
            get {
                return ResourceManager.GetString("AdditionalAndImportantInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There is no available Knowledge Base.
        /// </summary>
        public static string NoKB {
            get {
                return ResourceManager.GetString("NoKB", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to KnowledgeBaseInfo.
        /// </summary>
        public static string TaskName {
            get {
                return ResourceManager.GetString("TaskName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} time: {1} seconds.
        /// </summary>
        public static string TaskTime {
            get {
                return ResourceManager.GetString("TaskTime", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Working on Knowledge Base: &apos;{0}&apos; at &apos;{1}&apos;.
        /// </summary>
        public static string WorkingOnKnowledgeBase {
            get {
                return ResourceManager.GetString("WorkingOnKnowledgeBase", resourceCulture);
            }
        }
    }
}
