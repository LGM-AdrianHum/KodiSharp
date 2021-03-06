﻿using Smx.KodiInterop;
using Smx.KodiInterop.Python;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smx.KodiInterop.Modules.XbmcAddon
{
    public class Addon
    {
		public readonly PyVariable Instance = PyVariableManager.NewVariable(flags: PyVariableFlags.Object);

		/// <summary>
		/// Creates a new AddOn class.
		/// </summary>
		/// <param name="id">id of the addon as specified in addon.xml.
		/// If not specified, the running addon is used</param>
		public Addon(int? id = null) {
			Instance.CallAssign(
				new PythonFunction(PyModule.XbmcAddon, "Addon"),
				new List<object> { id }
			);
		}

		/// <summary>
		/// Returns the value of an addon property as a string.
		/// </summary>
		/// <param name="info">the property that the module needs to access.</param>
		/// <returns></returns>
		public string GetAddonInfo(AddonInfo info) {
			return Instance.CallFunction(
				new PythonFunction("getAddonInfo"),
				new List<object> { info.GetString() }
			);
		}

		/// <summary>
		/// Returns the value of a setting as a unicode string.
		/// </summary>
		/// <param name="setting">the setting that the module needs to access.</param>
		/// <returns></returns>
		public string GetSetting(string setting) {
			return Instance.CallFunction(
				new PythonFunction("getSetting"),
				new List<object> { setting }
			);
		}

		public T GetSetting<T>(string setting) where T : IConvertible {
			string value = GetSetting(setting);
			return (T)Convert.ChangeType(value, typeof(T));
		}

		/// <summary>
		/// Sets a script setting.
		/// </summary>
		/// <param name="setting">the setting that the module needs to access.</param>
		/// <param name="value">value of the setting.</param>
		public void SetSetting(string setting, object value) {
			Instance.CallFunction(
				new PythonFunction("setSetting"),
				new List<object> { setting, value }
			);
		}

		/// <summary>
		/// Opens this scripts settings dialog.
		/// </summary>
		public void OpenSettings() {
			Instance.CallFunction(
				new PythonFunction("openSettings")
			);
		}
    }
}
