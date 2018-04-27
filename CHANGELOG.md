# __3.0.1.2__ __2017-06-20__
## __RIS Technologist Quick info__
  - <h3>Features</h3>
  - Newly introduces quick info control. using that technologist can start/complete study. and also possible to add/remove attachments and comments.

## __RIS Technologist Schedule viewer__
  - <h3>Upgrade</h3>
    - indicate unconfirm appointments.
	- print unconfirm appointments using menu drop down on top right.
	- view appointments in a table using menu drop down on top right.
	
## __RIS Appointment Schedule viewer__
  - <h3>Upgrade</h3>
    - indicate unconfirm appointments.
	- print unconfirm appointments using menu drop down on top right.
	- view appointments in a table using menu drop down on top right.

## __Report/Worksheet template creation__
  - <h3>Upgrade</h3>
    - template must bind to a radiologist.

## __Report/Worksheet template selector__
  - <h3>Upgrade</h3>
    - remove tree view and added table view.
	- possible to filter using site, modality,category and radiologist name.
	
# __3.0.1.1__ __2017-04-23__
## __RIS Quick info__
  - <h3>Upgrade</h3>
    - Changed the UI.
    - introduces three new appointment lists. displaying not arrived, arrived, study in progress appointments.
    - introduces status change buttons to above list, so user can quickly change appointment's status.
    - user can add comments to the selected appointment from schedule viewer.

## __Schedule viewer__
  - <h3>Upgrade</h3>
    - Changed the UI.
    - remove appointment's status-filter drop down and introduces checkboxes to filter appointments by status.
	
## __Medicare Module__
  - <h3>Features</h3>
    - Newly introduces medicare feature.
    - user can create batches, submit batches, view process reports, view payment report, remove invoices from batches, quick access to appointments and patient.
    - user need permission to access this module. permission can be set from the user module.
	
## __User Module__
  - <h3>Upgrade</h3>
    - two permissions added. those are Medicare and Update Completed Appointment
    - Medicare permission : grant/revoke permission to Medicare module.
    - Update Completed Appointment : grant/revoke permission to update appointment once it is invoiced and completed.	
	
## __Radiologist(Dictation)____
  - <h3>Bugfixes</h3>
    - Report loading indicator disabled once report loaded.

## __Report viewer____
  - <h3>Bugfixes</h3>
    - Report loading indicator disabled once report loaded.
	
## __Authorise____
  - <h3>Bugfixes</h3>
    - Report loading indicator disabled once report loaded.

## __RIS Core__
  - <h3>Upgrade</h3>
    - When appointment status changed to ARRIVED, added attended by user.
	- Table modification to User module. removed its range key.
	- appointment comments store in a new table.
	
## __RIS Core__
  - <h3>Upgrade</h3>
    - Referral not needed check box added.
	
## __Settings__
  - <h3>Upgrade</h3>
    - Complete study without referral checkboxe added. once this is checked no need referral.
    - message broadcast keys added. 
	
# __3.0.1.0__ __2017-03-12__
## __RIS Core__
  - <h3>Upgrade</h3>
    - Upgrade telerik reporting and wpf controls to 2017 R1.
    - possible to enable/disable file upload progress window.
    - Added new log4net ConversionPattern to track RIS domain.
	
## __Verification__
  - <h3>Features</h3>
    - DICOM images automatically load when user select a report. 
    - User can enable/disable above feature from the local settings.
    - Added DICOM image open button to each row in the TYPED grid.
	
## __Patients__
  - <h3>Features</h3>
    - Patient medicare verification added.	
    - Patient can search using patient id.
    - Added new fields as guardian details.
	
## __Appointmants__
  - <h3>Features</h3>
    - New menu item added to view DICOM images in the schedule viewer.
    - New fields added to the appointment label printing.
    - Appointments in the scheduler now can filter using patient.
	
## __Radiology__
  - <h3>Features</h3>
    - Pending dictations are sort according to the report due time.

## __Typist__
  - <h3>UI</h3>
    - Audio graph moved to the bottom of the report editor.
  - <h3>Bugfixes</h3>
    - status changed to "DICTATED", report item added to the list through activity server.
	
## __QuickInfo__
  - <h3>Features</h3>
    - Display all the appointments associated with patient, except cancel appointments.
	
# __3.0.0.21__ __2017-02-15__
## __Settings__
  - <h3>Features</h3>
    - Added empty item to the default billing type under Billings tab.

## __RIS Core__
  - <h3>Bugfixes</h3>
    - RIS local settings re-set issue fixed.
    - Font change is not reflected issue fixed. Affected modules are radiologist, typist
      

# __3.0.0.17__ __2017-02-05__
## __Appointments__
  - <h3>Features</h3>
    - This release introduces support for overlap of appointments and special slots.

## __Patients__
  - <h3>Features</h3>
    - **(New Search Capabilities)** Now able to search by patient first name, last name and date of birth

## __Radiologist__
  - <h3>Features</h3>
    - Send to functionality changed
