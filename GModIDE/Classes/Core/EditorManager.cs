using GModIDE.PluginConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GModIDE.Classes
{
    public static class EditorManager
    {
        #region Fields
        private static List<IEditor> _editors = new List<IEditor>();
        private static IEditor _designer = null;
        private static IEditor _coder = null;
        #endregion

        #region Properties
        /// <summary>
        /// The current designer editor
        /// </summary>
        public static IEditor Designer
        {
            get
            {
                StackTrace st = new StackTrace(true);
                String err = "GMod IDE tried to access current editor for designing but null was found";
                if (_designer == null) { ErrorHandler.CreateError(new InvalidOperationException(err), err + Environment.NewLine + "Stack Trace:" + Environment.NewLine + Environment.NewLine + st.ToString()); }
                return _designer;
            }
        }

        /// <summary>
        /// The current coding editor
        /// </summary>
        public static IEditor Coder
        {
            get
            {
                StackTrace st = new StackTrace(true);
                String err = "GMod IDE tried to access current editor for coding but null was found";
                if (_designer == null) { ErrorHandler.CreateError(new InvalidOperationException(err), err + Environment.NewLine + "Stack Trace:" + Environment.NewLine + Environment.NewLine + st.ToString()); }
                return _coder;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Register a new editor
        /// </summary>
        /// <param name="editor">Editor</param>
        public static void RegisterEditor(IEditor editor)
        {
            _editors.Add(editor);
        }

        /// <summary>
        /// Proccess editors
        /// </summary>
        public static void ProcessEditors()
        {
            /* not enough editors */
            if (_editors.Count < 2)
            {
                StackTrace st = new StackTrace(true);
                String err = "GMod IDE does not have enough editors to load primary functionality";
                ErrorHandler.CreateError(new InvalidOperationException(err), err + Environment.NewLine + "Stack Trace:" + Environment.NewLine + Environment.NewLine + st.ToString());
            }

            bool setDesigner = false;
            bool setCoder = false;
        CheckEditors:
            /* if there are no default designer/coder set, set it - if they are set try and load them from list */
            
            foreach (IEditor editor in _editors)
            {
                if (_designer == null && (string)SettingsManager.PrimarySettings["current_designer"] == "" && editor.EditorType == EditorType.DESIGNER)
                {
                    _designer = editor;
                    setDesigner = true;
                    SettingsManager.PrimarySettings["current_designer"] = editor.Name;
                }
                else if (_coder == null && (string)SettingsManager.PrimarySettings["current_coder"] == "" && editor.EditorType == EditorType.CODER)
                {
                    _coder = editor;
                    SettingsManager.PrimarySettings["current_coder"] = editor.Name;
                    setCoder = true;
                }
                else if ((string)SettingsManager.PrimarySettings["current_designer"] == editor.Name)
                {
                    _designer = editor;
                    setDesigner = true;
                }
                else if ((string)SettingsManager.PrimarySettings["current_coder"] == editor.Name)
                {
                    _coder = editor;
                    setCoder = true;
                }
            }

            /* check to see if user-changed editors are no longer available */
            bool recheck = false;
            if (_designer == null && (string)SettingsManager.PrimarySettings["current_designer"] != "")
            {
                SettingsManager.PrimarySettings["current_designer"] = "";
                recheck = true;
            }
            if (_coder == null && (string)SettingsManager.PrimarySettings["current_coder"] != "")
            {
                SettingsManager.PrimarySettings["current_coder"] = "";
                recheck = true;
            }
            if (recheck == true) { goto CheckEditors; }
            
            /* make sure both a coder and designer was found */
            if (setDesigner == false || setCoder == false)
            {
                StackTrace st = new StackTrace(true);
                String err = "GMod IDE does not have a default designer and/or coder - are you missing critical plugins?";
                ErrorHandler.CreateError(new InvalidOperationException(err), err + Environment.NewLine + "Stack Trace:" + Environment.NewLine + Environment.NewLine + st.ToString());
            }

            /* save settings */
            SettingsManager.Save();
        }
        #endregion
    }
}
