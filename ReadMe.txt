Prerequisite
	- .Net Framework 4.5
	- If the network is using Proxy server, please setup proxy in Internet Explorer in advance.

How to use
	Just execute Minamike.exe from command line.
	Command line options are as follows
	
	Minamike.exe [target URL] [retry count] [interval]
	
	targetURL: Specify URL of the target content.
				Default is "https://aeon-test.jdadelivers.com/Citrix/XenApp/media/CitrixXenApp.png"
				
	retry count: Specify the number of requests
				Default is 50
				
	interval;Specify interval between requests in millisecond
				Default is 1000

When executed, following information is written into Standard Out.
Redirect it to appropriate file and analyze later.

=============================================================================
Target:https://aeon-test.jdadelivers.com/Citrix/XenApp/media/CitrixXenApp.png
Retry Count:50
Interval:1000msec
Current Time:2013/04/08 08:05:45
Bytes Received, Time Taken
2269,00:00:01.0310103
2269,00:00:00.1619157
2269,00:00:00.1597396
2269,00:00:00.1607351
2269,00:00:00.1606442
2269,00:00:00.1721122
=============================================================================

Please refert to Run.bat
