<?php
// Copyright (c) 2020 Davide Gironi
//
// Please refer to LICENSE file for licensing information.

defined( '_VALID_' ) or die( 'Restricted access' );

if(!$login->isLoggedIn) {
 echo $lang['PAGE_RESTRICTED'];
 return;
}

?>

<div id='calendar'></div>
<br/><br/>

<div id="fullCalModal" class="modal fade">
<div class="modal-dialog">
	<div class="modal-content">
		<div class="modal-header">
			<button type="button" class="close" data-dismiss="modal" aria-hidden="true">x</button>
			<h4 id="fullCalModalTitle" class="modal-title"></h4>
		</div>
		<div id="fullCalModalBody" class="modal-body"></div>
		<div class="modal-footer">
			<button type="button" class="btn btn-default" data-dismiss="modal"><?php echo $lang['MODALEVENT_CLOSE']; ?></button>
		</div>
	</div>
</div>
</div>

<script>
$(document).ready(function() {
  function get_calendar_height() {
	return $(window).height() - 150;
  }
  $(window).resize(function() {
	$('#calendar').fullCalendar('option', 'height', get_calendar_height());
  });
  $('#calendar').fullCalendar({
	header: { 
	  left: 'prev,next today',
	  center: 'title',
	  right: 'month,agendaWeek,agendaDay'
	},
	height: get_calendar_height(),
	editable: false,
	lang: '<?php echo $language;?>',
	events: 'index.php?ajax=1&f=events',
	defaultView: '<?php echo $calendarStartPage; ?>',
	scrollTime: '<?php echo $calendarScrollTime; ?>',
	eventClick: function(calEvent, jsEvent, view) {
	  $('#fullCalModalTitle').html(calEvent.title);
	  $('#fullCalModalBody').html(calEvent.description);
	  $('#fullCalModal').modal();
	}
  });
});
</script>
