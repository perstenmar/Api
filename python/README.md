# Dependencies

## httplib2

https://code.google.com/p/httplib2/

### Install on osx

1. Download httplib2 onto your computer
1. cd into the directory when you unpacked httplib2
1. Run ```python setup.py install```

Alternately, you can run:
~$ python /path/to/httplib2/setup.py install

### Install on ubuntu/debian 

```apt-get install python-httplib2```

# Example Usage

**See example.py for more examples**

```python
#!/usr/bin/python

from CoursioApi import CoursioApi
coursio = CoursioApi('6bee83c2-75a5-4400-aff3-a3315403b896', '$1$VgoLUt/N$27QP.Z8K8ThiRsTqcNOyV1', 'pepper')
coursio.get('/v1/invitation', 1);
```