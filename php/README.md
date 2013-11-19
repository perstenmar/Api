Usage
=====

```
require_once YOUR_PATH_TO_CoursioApi.php;

$API = new CoursioApi (YOUR_PUBLIC_KEY, YOUR_PRIVATE_KEY, YOUR_SALT);

$result = $API->Get('courses');
print_r($result);

$result = $API->Post('invitations', array
(
    'courseId' => 65,
));
print_r($result);

```