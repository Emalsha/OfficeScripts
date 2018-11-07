from xml.dom import minidom
import os

path = r"C:\Users\emalsha.rasad\Desktop\CampusNet Client\CampusNet Corporate\Dashboards"

for filename in os.listdir(path):
    if not filename.endswith('.xml'): continue
    fullname = os.path.join(path, filename)
    
    doc = minidom.parse(fullname)
    print('FILE : ' + filename)
    widget = doc.getElementsByTagName('Widget')

    for w in widget:
        for e in w.getElementsByTagName('Property'):
            if e.attributes['Name'].value == 'EntitySourceName':
                if e.hasAttribute('Value') == 0:
                    print(' No Source value : '+ w.attributes['Caption'].value + ' in file '+ filename)

