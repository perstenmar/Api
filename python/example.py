#!/usr/bin/python

from CoursioApi import CoursioApi
coursio = CoursioApi('6bee83c2-75a5-4400-aff3-a3315403b896', '$1$VgoLUt/N$27QP.Z8K8ThiRsTqcNOyV1', 'pepper')
#print coursio.get('/v1/invitations');
#print coursio.post('/v1/invitations', '{"courseId": 65}');
#print coursio.delete('/v1/invitations', 52);
print coursio.put('/v1/userCirclePermissions', 4, '{"userId":"2","circleId":"1"}');