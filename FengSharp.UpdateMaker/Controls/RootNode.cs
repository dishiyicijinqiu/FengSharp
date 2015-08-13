using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FengSharp.UpdateMaker.Controls
{
	class RootNode : FolderNode
	{
		public RootNode(string path)
			: base(path, path)
		{
			Text = "根目录";
			ImageKey = SelectedImageKey = "home";
		}
	}
}
