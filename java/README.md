Usage
=====

```
package Your_Package_name;

import CoursioApi.CoursioApi;

public class CoursioTest
{
    public static void main(String args[]) throws Exception
    {
        CoursioApi API = new CoursioApi(YOUR_PUBLIC_KEY, YOUR_PRIVATE_KEY, YOUR_SALT);

        String result;

		result = API.Get ("courses", 0);
		System.out.println (result);

		result = API.Post ("invitations", "{\"courseId\":\"65\"}");
		System.out.println (result);
    }
}
```