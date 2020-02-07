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

NOTES:
- The BC and simulated RTs have some individual Command Channels to Start and Stop them. The Command execution is triggered when a "1" value is written on NI-VeriStand Channel (value comes back to 0 automatically).
- For Acyclic frame(s), emission (one at a time) is triggered when a "1" value is written on associated Trigger NI-VeriStand Channel.
- If accepted by user during HardWare XML Load, there are TimeStamp Channels whenever it's available. This directly comes from the read Record (the 1553 frame) returned by the driver. It's the board time. So, for one 1553 frame, same TimeStamp information can be written to several NI-VeriStand TimeStamp channels (TimeStamp Channel from BC, TimeSTamp Channel from RT(s)).
- To support broadcast frames, user needs to define a Remote Terminal at TA Address = 31. There is an XML attribute "broadcast", at Channel level, which defines whether TA address is used for RT at address 31 or as the broadcast RT. Refer to Ballard documentation (Cf. XML Schema) for more information.


### LabVIEW Version ###

LabVIEW 2017

### Built Availability ###

No Build available.

### Quality, Limitations ###

- This IP is new. Testing was done with XML examples available here.
- This IP doesn't support Parameters (from and to Words). This is described in Issue #2.
- Github Issues numbering: below 4, can refer to 2 different things (in the commits comments) as the repository was imported from a first private repository but issues not imported.
- Scenario we monitor RTs only (not simulated) has not been tested at all.

### Hardware Configuration Files Examples ###

This IP comes with some XML HW examples available here: https://github.com/NIVeriStandAdd-Ons/Ballard-MIL-STD-1553-Custom-Device/tree/master/Example%20Database
- "1553_HW_Reference_007.xml". This example doesn't need external wiring. This example shows different frame types including some broadcast. There is one BC and couple of RTs simulated on Channel 0.
- "1553_HW_Reference_007_BC Ch0_RTs Ch1.xml". This example needs external wiring between Channel 0 and Channel 1. This example shows different frame types including some broadcast. There is one BC and couple of RTs simulated. BC runs on Channel 0 and RTs run on Channel 1.

In XML file, it's important to note that Buffers attached to Messages need to have the right size, particularly for the RTs. The code detects the actual size of requested Buffer to figure-out the NI-VeriStand Channels to be allocated.

### CPU Performances ###

With example file "1553_HW_Reference_007_BC Ch0_RTs Ch1.xml" running under NI-VeriStand 2017, Primary Control Loop set at 1000 Hz, on a PXIe-8840 (dual core), without using Command channels or update data, here are code sections duration (in us) read in Channel Data Viewer:
- Inline Read Time: 49 us;
- Inline Write Time: 7 us;
- Asynchronous Loop Time : 11 us. 

With example file "1553_HW_Reference_007_BC Ch0_RTs Ch1.xml" running under NI-VeriStand 2017, Primary Control Loop set at 1000 Hz, on a PXIe-8840 (dual core), without using Command channels, with systematic data update at each PCL iteration for 44 Words, here are code sections duration (in us) read in Channel Data Viewer:
- Inline Read Time: 49 us;
- Inline Write Time: 7 us;
- Asynchronous Loop Time : 54 us. 

### Built Dependencies ###

[Astronics Ballard LabVIEW Driver 1.2.0.2 or Higher] http://www.ni.com/download/ballard-pxie-omnibus-ii-1.2.0/8336/en/

### Source Dependencies ###

[Astronics Ballard LabVIEW Driver 1.2.0.2 or Higher] http://www.ni.com/download/ballard-pxie-omnibus-ii-1.2.0/8336/en/

[OpenG Array Library 4.1.1.14 or Higher] vipm://oglib_array?repo_url=http://www.jkisoft.com/packages

[OpenG MD5 Digest Library 4.1.1.10 or Higher] vipm://oglib_md5?repo_url=http://www.jkisoft.com/packages

[NI VeriStand Addon Inline-Async-APIs 1.0.0 or Higher] https://github.com/ni/niveristand-custom-device-inline-async-api/releases/tag/v1.0.0

Code uses one .NET Assembly compiled into a DLL to import Hardware XML File. The source code is available here: https://github.com/NIVeriStandAdd-Ons/Ballard-MIL-STD-1553-Custom-Device/tree/master/Source/Assemblies/HW%20XML%20Files

VIs must be renamed in BTI1553LV.lvlib to prevent naming collision during compilation see User Readme.rtf

### License ###

*This repository and any materials provided by NI therein are provided AS IS. NI DISCLAIMS ANY AND ALL LIABILITIES FOR AND MAKES NO WARRANTIES, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY WARRANTIES OF MERCHANTABILITY, FITNESS FOR  PARTICULAR PURPOSE, OR NON-INFRINGEMENT OF INTELLECTUAL PROPERTY. NI shall have no liability for any direct, indirect, incidental, punitive, special, or consequential damages for your use of the repository or any materials contained therein.*
