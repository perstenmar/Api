#!/usr/bin/python
from CoursioApi import CoursioApi

# Initate class with PUBLIC_KEY, PRIVATE_KEY and SALT
coursio = CoursioApi('YOUR_PUBLIC_KEY', 'YOUR_PRIVATE_KEY', 'A_SALT_WITH_PEPPER')

# Get all invitations
#print coursio.get('/v1/invitations');

# Create a new invitaiton for courseId 65
#print coursio.post('/v1/invitations', '{"courseId": 65}');

# Delete invitation with ID 52
#print coursio.delete('/v1/invitations', 52);

# Change the userCirclePermission with id 4 to relate to userId 2 and circleId 1
#print coursio.put('/v1/userCirclePermissions', 4, '{"userId":"2","circleId":"1"}');