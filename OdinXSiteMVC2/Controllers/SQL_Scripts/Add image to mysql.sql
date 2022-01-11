SELECT * FROM odinxusers.exec;
 Delete from odinxusers.exec
 where execID >= 4;
 insert into odinxusers.exec (execPic) 
 values (load_file('E:\Github_Local_Repo\OdinxSite_Port\OdinXSiteMVC2\wwwroot\Assets\Pic\Goblogo.png'));
SELECT * FROM odinxusers.exec;