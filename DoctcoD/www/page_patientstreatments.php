<?php
// Copyright (c) 2020 Davide Gironi
//
// Please refer to LICENSE file for licensing information.

defined( '_VALID_' ) or die( 'Restricted access' );

if(!$login->isLoggedIn || $login->userType != 'D') {
 echo $lang['PAGE_RESTRICTED'];
 return;
}

//List all patient treatments
function patienttreatments() {
  global $mssql, $lang, $login;
  
  $pt_array = array();
  $query = <<<'EOT'
SELECT
  pt.patientstreatments_id AS id,
  p.patients_surname + ' ' + p.patients_name + ' (' + CONVERT(varchar(10), p.patients_id) + ')' AS patient,
  p.patients_id AS patientid,
  tt.treatmentstypes_name AS treatment,
  CONVERT(varchar(25), pt.patientstreatments_creationdate) AS date,
  patientstreatments_description AS description,
  patientstreatments_notes AS note
FROM patientstreatments pt
  INNER JOIN doctors d ON pt.doctors_id = d.doctors_id
  INNER JOIN patients p ON pt.patients_id = p.patients_id
  INNER JOIN treatments t ON pt.treatments_id = t.treatments_id
  INNER JOIN treatmentstypes tt ON t.treatmentstypes_id = tt.treatmentstypes_id
WHERE
EOT;
  $query .= " d.doctors_id = " . (int)$login->userId;
  $query .= " ORDER BY pt.patientstreatments_creationdate DESC";

  $mssqlData = $mssql->fetchData($query);
  foreach ($mssqlData as $row) {
    $pt_array[] = array(
      'id' => $row['id'],
      'patient' => $row['patient'],
      'patientid' => $row['patientid'],
      'treatment' => $row['treatment'],
      'date' => date("Y/m/d", strtotime(strval($row['date']))),
      'description' => $row['description'],
      'note' => $row['note']
    );
  }
  
  return $pt_array;
}

$pt_array = patienttreatments();
?>

<style>
.dhtmlcontnent>p {
  margin: 0;
  padding: 0;
}
</style>

<form>
  <div class="form-group">
    <label><?php echo $lang['PATIENTSTREATMENTS_SELECTPATIENT'] ?></label>
    <select class="form-control" onChange="location='?page=<?php echo $_GET['page'] ?>&patientid='+this.value">
      <option value=0>/</option>
    <?php
    $patients = array();
    foreach ($pt_array as $pt) {
    if(!in_array($pt['patientid'], $patients)) {
      array_push($patients, $pt['patientid']); ?>
      <option value=<?php echo $pt['patientid']; ?> <?php echo (isset($_GET['patientid']) && $_GET['patientid'] == $pt['patientid'] ? "selected" : "") ?>><?php echo $pt['patient']; ?></option>
    <?php
      }
    } ?>
    </select>
  </div>
</form>

<?php
if(isset($_GET['patientid'])) {
  $foundone = false;
  foreach ($pt_array as $pt)
   if($_GET['patientid'] == $pt['patientid']) $foundone = true;
  if($foundone) {
?>
<label><?php echo $lang['PATIENTSTREATMENTS_TREATMENTS'] ?></label>
<div class="panel-group" id="patientstreatments" role="tablist">
<?php
  foreach ($pt_array as $pt) {
    if($_GET['patientid'] == $pt['patientid']) { ?>
  <div class="panel panel-default">
    <div class="panel-heading" role="tab" id="heading<?php echo $pt['id']; ?>">
      <h4 class="panel-title">
        <a role="button" class="collapsed" data-toggle="collapse" data-parent="#patientstreatments" href="#collapse<?php echo $pt['id']; ?>" aria-controls="collapse<?php echo $pt['id']; ?>">
          <b><?php echo $lang['PATIENTSTREATMENTS_DATE'] ?></b> <?php echo $pt['date']; ?>
        </a>
      </h4>
    </div>
    <div role="tabpanel" id="collapse<?php echo $pt['id']; ?>" class="panel-collapse collapse" aria-labelledby="heading<?php echo $pt['id']; ?>">
      <div class="panel-body">
        <form>
          <div class="form-group">
            <label><?php echo $lang['PATIENTSTREATMENTS_TREATMENT'] ?></label>
            <div class="panel panel-default">
              <div class="panel-body dhtmlcontnent">
                <?php echo $pt['treatment']; ?>
              </div>
            </div>
          </div>
          <div class="form-group">
            <label><?php echo $lang['PATIENTSTREATMENTS_DESCRIPTION'] ?></label>
            <div class="panel panel-default">
              <div class="panel-body">
                <?php echo !empty($pt['description']) ? $pt['description'] : "/"; ?>
              </div>
            </div>
          </div>
          <div class="form-group">
            <label><?php echo $lang['PATIENTSTREATMENTS_NOTE'] ?></label>
            <div class="panel panel-default">
              <div class="panel-body">
                <?php echo !empty($pt['note']) ? $pt['note'] : "/"; ?>
              </div>
            </div>
          </div>
        </form>
      </div>
    </div>
  </div>
  <?php
    }
  } ?>
</div>
<?php
 }
} ?>
