using Microsoft.Win32;

namespace SMORemover
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.Title = "SMO (Show More Options) Remover";

			string? response = null;
			goto prompt;

		prompt:
			{
				Console.Clear();
				Console.WriteLine("The following Registry actions will be performed:\n");
				Console.WriteLine("Open Key -> \"CurrentUser\\Software\\Classes\\CLSID\"");
				Console.WriteLine("Create Key -> {86ca1aa0-34aa-4e8b-a509-50c905bae2a2}");
				Console.WriteLine("Open Key -> {86ca1aa0-34aa-4e8b-a509-50c905bae2a2}");
				Console.WriteLine("Create Key -> InprocServer32");
				Console.WriteLine("Close Keys and Release Resources\n");

				Console.Write("Do you consent to these modifications of the Registry? (yes/y) or (no/n) ");
				response = Console.ReadLine();

				if (response?.ToLower() == "yes" || response?.ToLower() == "y")
					goto yes;
				else if (response?.ToLower() == "no" || response?.ToLower() == "n")
					return;
				else goto prompt;

			}

		yes:
			{
				RegistryKey? key = Registry.CurrentUser.OpenSubKey("Software\\Classes\\CLSID", true);
				RegistryKey key1 = key.CreateSubKey("{86ca1aa0-34aa-4e8b-a509-50c905bae2a2}", true);
				RegistryKey key2 = key1.CreateSubKey("InprocServer32", true);
				key2.SetValue("", "");

				key2.Close();
				key1.Close();
				key.Close();
			}
		}
	}
}