Usage
=====

```
using System;

namespace CoursioTest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var API = new CoursioApi (YOUR_PUBLIC_KEY, YOUR_PRIVATE_KEY);

			string result;

			result = API.Get ("courses");
			Console.WriteLine (result);

			result = API.Post ("invitations", "{\"courseId\":\"65\"}");
			Console.WriteLine (result);
		}
	}
}
```