# ECNF GarbageCollector Test
###Modul: ecnf
###Written by: Philipp Steiner
###Summary:
This application calculates the elapsed time and the amount of space used by
the specific GarbageCollector wich can by set in de App.config
###Tested GarbageCollectors
* GC Workstation: gcAllowVeryLargeObjects enabled="false"  gcServer enabled="false" gcConcurrent enabled="false"
* GC Server: gcAllowVeryLargeObjects enabled="false"  gcServer enabled="true" gcConcurrent enabled="false"
* GC Concurrent Workstation: gcAllowVeryLargeObjects enabled="false"  gcServer enabled="false" gcConcurrent enabled="true"
* GC Concurrent Server: gcAllowVeryLargeObjects enabled="false"  gcServer enabled="true" gcConcurrent enabled="true"
* GC Concurrent Workstation VLO: gcAllowVeryLargeObjects enabled="true"  gcServer enabled="false" gcConcurrent enabled="true"
* GC Concurrent Server VLO: gcAllowVeryLargeObjects enabled="true"  gcServer enabled="true" gcConcurrent enabled="true"