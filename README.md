### Ballard MIL-STD-1553 Custom Device ###

**Ballard MIL-STD-1553 Custom Device** allows users to use the [Ballard MIL-STD-1553 devices]
(https://www.ni.com/en-ca/shop/select/pxi-mil-std-1553-interface-module) inside NI VeriStand. This is an avionic interface bus 
standard. It's important to note that supported hardware are the "NI-Keyed boards only" AND Multi-Function. 
Product Part Numbers supported :
-  LV-222-550-000
-  LV-222-555-000
-  LV-222-555-555

The code uses the Sequential Monitor to monitor the records on the channels. It relies on Bus Monitor enabled. It's why we need a Multi-Function model. 

It's not implemented in the current code but if a chronological mode was required, it could be added. Mechanism to read the traffic in a chronological manner is already in place and used in the Custom Device. The current code parses/consumes the read records and updates the respective NI-VeriStand Channels. Another consumer could be added to the code to log or share (via network for instance) the traffic.

### LabVIEW Version ###

LabVIEW 2017

### Built Availability ###

No Build available.

### Quality, Limitations ###

This IP is new. 

### Built Dependencies ###

[Astronics Ballard LabVIEW Driver 1.2.0.2 or Higher] http://www.ni.com/download/ballard-pxie-omnibus-ii-1.2.0/8336/en/

### Source Dependencies ###

[Astronics Ballard LabVIEW Driver 1.2.0.2 or Higher] http://www.ni.com/download/ballard-pxie-omnibus-ii-1.2.0/8336/en/

[OpenG Array Library 4.1.1.14 or Higher] vipm://oglib_array?repo_url=http://www.jkisoft.com/packages

[OpenG MD5 Digest Library 4.1.1.10 or Higher] vipm://oglib_md5?repo_url=http://www.jkisoft.com/packages

[NI VeriStand Addon Inline-Async-APIs 1.0.0 or Higher] https://github.com/ni/niveristand-custom-device-inline-async-api/releases/tag/v1.0.0

Code uses 1 .NET Assembly compiled into a DLL. The source code is available here:

	Hardware XML File: https://github.com/NIVeriStandAdd-Ons/Ballard-MIL-STD-1553-Custom-Device/tree/master/Source/Assemblies/HW XML Files

VIs must be renamed in BTI1553LV.lvlib to prevent naming collision during compilation see User Readme.rtf

### License ###

*This repository and any materials provided by NI therein are provided AS IS. NI DISCLAIMS ANY AND ALL LIABILITIES FOR AND MAKES NO WARRANTIES, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY WARRANTIES OF MERCHANTABILITY, FITNESS FOR  PARTICULAR PURPOSE, OR NON-INFRINGEMENT OF INTELLECTUAL PROPERTY. NI shall have no liability for any direct, indirect, incidental, punitive, special, or consequential damages for your use of the repository or any materials contained therein.*
