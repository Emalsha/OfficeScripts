from xml.dom import minidom
import os
import sys
reload(sys)
sys.setdefaultencoding('utf8')

path = r'C:\Users\emalsha.rasad\Documents\TokenMappingSort\TokenMapping.xml'

doc = minidom.parse(path)
print('FILE : READ')
mapper = doc.getElementsByTagName('TokenMapper')

mlist = {}

for m in mapper:
    lkey = m.getElementsByTagName('ID')[0].firstChild.data
    mlist[lkey] = m
print('Sorting start...')
d = sorted(mlist.items())
doc = minidom.Document()
node = doc.createElement('TokenMapping')
node.setAttribute('xmlns',"http://schemas.datenlotsen.de/configuration/tokenmapping")

for k,v in d:
    v.getElementsByTagName('ID')[0].firstChild.data
    node.appendChild(v)
doc.appendChild(node)    
print('Sorting end...')
doc.writexml(open('SortedXML.xml','w'), indent='  ',encoding='utf-8')
print('FILE : DONE')
