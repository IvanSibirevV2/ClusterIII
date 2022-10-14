
  if (pageTitle === false || pageTitle == null) var pageTitle = document.title;
  
  $(document).ready(function() {
    
    $('.enter_link').click(function() {
      
      $('#popup_login').css('display', 'block');
      
      if ($(this).hasClass('login')) {
        $('#popup_login .show_tab.signin').trigger('click');
      } else {
        $('#popup_login .show_tab.signup').trigger('click');
      }
      
      return false;
      
    });
    
    $('.close_popup').click(function() {
     
      $(this).parent().parent().css('display', 'none'); return false;
      
    });

    $('html').click(function(e) {
      
      if ($(e.target).closest('#popup_login').length == 0) {
        $('#popup_login').css('display', 'none');
      }
      
    });
    
    $(this).keydown(function(eventObject) {
      
      if (eventObject.which == 27) $('#popup_login').css('display', 'none');
      
    });
    
    $('#popup_login .show_tab').click(function() {
      
      $('#popup_login .login_block').hide();
      $('#popup_login .block_'+$(this).attr('href').substr(1)).show();
      $('#popup_login .show_tab').removeClass('selected');
      $(this).addClass('selected');
      
      $('#popup_login .block_'+$(this).attr('href').substr(1)+' input').eq(0).focus();
      
      return false;
      
    });
  
    $(function() {
      if ($(".sidebar_fix").offset() !== null) {
        //var offset = $(".sidebar_fix").offset();
        var offset = $(".filter").offset();
        var topPadding = 15;
        var bannerH = $('.banner_top').height();
        $(window).scroll(function() {
          if (!$('.sidebar_fix').hasClass('show_sidebar')) {
            if ($(window).scrollTop() > (offset.top + bannerH + 100)) {
              $(".sidebar_fix").addClass('fixed_sidebar');
            }
            else {
              $(".sidebar_fix").removeClass('fixed_sidebar');
            }
          }
        });
      }
    });
  
    // --- Вопросы и предложения - ответ на сообщение
    $('.feedback_list .get_answer a').click(function() {
      $form = $('<form>');
      $form.attr('action', '/feedback/');
      $form.attr('method', 'post');
      $form.append($('#feedbackForm').html());
      
      $form.find('.btn_blue').val('Ответить в тему');
  
      $(this).hide();
      $(this).parent().prepend($form);
      $(this).parent().find('#txtName').focus();
      $(this).parent().find('#parentId').val($(this).attr('href').substr(1));
  
      return false;
    });
  });
  
  
  
  //if (pageTitle === false || pageTitle == null) var pageTitle = document.title;
  var sysMsgId = new Array;
  
  function checkNewSysMessage(folderId, addHistory)
  {
    serverResponse = new AjaxRequest("/_ajax/message.xml.php");
    serverResponse.add("action", "getSysMessageNew");
    serverResponse.add("last_msg_id", sysMsgID);
    serverResponse.setHandler(on_ShowSysMessage);
  
    response = serverResponse.execute();
  }
  
  function on_ShowSysMessage(currentObject)
  {
    var resultXML 	= currentObject.resultXML;
    window.sysMsgId = new Array; index = 0;
    errorData 		= resultXML.getElementsByTagName('Error')[0];
  
    if (errorData.getAttribute('code') == 0)
    {
      var listData    = resultXML.getElementsByTagName('List')[0];
      if (listData.getAttribute('count') > 0) {
        var messageList = resultXML.getElementsByTagName('Message');
        for (i=0; i<messageList.length; i++) {
          msgId   = messageList[i].getAttribute('id');
          msgType = messageList[i].getAttribute('type');
          msgText = messageList[i].getAttribute('text');
  
          $li = $('<li>');
          $li.append(msgText);
          $('#sysmessage_list').append($li);
  
          sysMsgID = msgId;
        }
  
        if ($('#sysmessage_box').css('display') == 'none') {
          $('#sysmessage_box').slideDown(600);
        }
  
        elf.exec('reload');
      }
      else {
        // No new messages
      }
    }
    else
    {
      alert(errorData.getAttribute('message'));
      //document.getElementById('imgLoading').style.display = 'none';
    }
  
    return true;
  }
  
  function hideMessage() {
    serverResponse = new AjaxRequest("/_ajax/message.xml.php");
    serverResponse.add("action", "closeSysMessage");
    serverResponse.setHandler(on_MessageClose);
  
    response = serverResponse.execute();
  
    $('#sysmessage_box').slideUp();
    $('#sysmessage_list').html('');
  }
  
  function on_MessageClose(currentObject)
  {
    //var resultXML 	= currentObject.resultXML;
    //errorData 		= resultXML.getElementsByTagName('Error')[0];
  
    return true;
  }
  function on_closePopup(popupId) {
    $('#'+popupId).css('display', 'none');
    return false;
  }
  
  function on_selectUniversity() {
    window.location = rootUrl+'/my/files/university:'+document.getElementById('ddlUniversity').value+'/';
  }
  
  function on_goToSort() {
    window.location = rootUrl+'/my/files/sort:'+localStorage.getItem('elfinder-lastdirelfinder')+'/';
    return false;
  }
  
  $(document).ready(function() {
  
    $('#showPopupCheckFiles').click(function() {
      $.ajax({
        url:rootUrl+'/api/files.json.php', 
        type:'GET',
        data:'method=checkFilesGetStatus',
        success: function(response) {
          $('#popup_check_files').css('display', 'block');
          if (response.error_code) {
            $('#popup_check_files input').css('display', 'none');
            $('#popup_check_files .cancel').css('display', 'inline-block');
            $('#popup_check_files .alert_text').html(response.message);
          } else {
            $('#popup_check_files input').css('display', 'inline-block');
            $('#popup_check_files #txtPurseNum').val(response.purse_num);
            $('#popup_check_files #txtPurseNum').focus();
            $('#popup_check_files .alert_text').html(response.message);
          }
        }
      });
      return false;
    });
  
    $('#showPopupAddSubject').click(function() {
      if (typeof elf !== 'undefined') elf.disable();
  
      $('#popup_add_subject').css('display', 'block');
      $('#popup_add_subject #filterKey').focus();
      if ($('#popup_add_subject #filterKey').val()) {
        $('#popup_add_subject #filterKey').val('');
        on_columnFilterKey('', 'subject_select');
      }
      return false;
    });
  
    $('#showPopupRemoveUnisercity').click(function() {
      $('#popup_remove_university').css('display', 'block');
      return false;
    });
  
    $('#showPopupAddUniversity').click(function() {
      if (typeof elf !== 'undefined') elf.disable();
  
      $('#popup_add_university').css('display', 'block');
      $('#popup_add_university #filterKey').focus();
      if ($('#popup_add_university #filterKey').val()) {
        $('#popup_add_university #filterKey').val('');
        on_columnFilterKey('', 'select_university');
      }
      return false;
    });
  
    $('.action .select').click(function() {
      $('#popup_set_subject').css('display', 'block');
  
      $('#tab__select_subj').show();
      $('#tab__add_new_subj').hide();
      $('#_tab__select_subj').addClass('selected');
      $('#_tab__add_new_subj').removeClass('selected');
      $('#popup_set_subject #filterKey').focus();
      if ($('#popup_set_subject #filterKey').val()) {
        $('#popup_set_subject #filterKey').val('');
        on_columnFilterKey('', 'subject_select_sort');
      }
      localStorage.setItem('folder-selected-id', $(this).parent().parent().attr('id'));
      return false;
    });
  
    $('#subject_select_sort a').live('click', function() {
      $liId = localStorage.getItem('folder-selected-id');
      $('#'+$liId+' .select').html($(this).text());
      $('#'+$liId+' .select').addClass('checked');
      $('#'+$liId+' .cancel').removeClass('hidden');
      $('#'+$liId+' .label').html('переместить в');
      $('#set_folder_'+$liId).val($(this).attr('href').substr(1));
      $('#popup_set_subject').css('display', 'none');
      $('.cancel_all').removeClass('hidden');
      return false;
    });
  
    $('.cancel').click(function() {
      $liId = $(this).parent().parent().attr('id');
      $('#'+$liId+' .select').html('выберите вручную');
      $('#'+$liId+' .label').html('предмет не найден');
      $('#'+$liId+' .select').removeClass('checked');
      $('#set_folder_'+$liId).val(0);
      $(this).addClass('hidden');
      if ($('.cancel:visible').length == 0) {
        $('.cancel_all').addClass('hidden');
      }
      return false;
    });
  
    $('.cancel_all').click(function() {
      $('.action .select').html('выберите вручную');
      $('.action .label').html('предмет не найден');
      $('.action .select').removeClass('checked');
      $('.folder_sort ul input').val(0);
      $('.cancel').addClass('hidden');
      $('.cancel_all').addClass('hidden');
      return false;
    });
  
    $('#btnSave').click(function() {
      if ($('.cancel:visible').length == 0) {
        alert('Не выбраны предметы для перемещения.');
        return false;
      }
    });
  
    $('#popup_set_subject #btnAddSubject').click(function () {
      var regAbbreviation = /^(.){0,10}$/;
      var regName         = /^(.){1,255}$/;
  
      $('#tab__add_new_subj .message').remove();
      $('#addSubjectForm input').removeClass('popup_input_error');
      $('#addSubjectForm select').removeClass('popup_input_error');
  
      if(regName.test($('#txtNameSubj').val()) == false || regAbbreviation.test($('#txtAbbreviationSubj').val()) == false || !($('select#ddlParent').val()*1)) {
  
        $message = $('<div>');
        $message.addClass('message');
  
        if (regName.test($('#txtNameSubj').val()) == false) {
          $('#txtNameSubj').addClass('popup_input_error');
          $message.append('<div id="alert">Поле "Полное название" не может быть пустым.</div>');
        }
        if (!($('select#ddlParent').val()*1)) {
          $('select#ddlParent').addClass('popup_input_error');
          $message.append('<div id="alert">Вам нужно выбрать рездел.</div>');
        }
  
        $('#tab__add_new_subj .infobox').after($message);
  
        return false;
      }
  
      var parameter = $("#addSubjectForm").serialize();
      // отправить запрос на добавление записи
      $.ajax({
        url:rootUrl+'/api/files.json.php', 
        type:'GET',
        data:'method=addSubject&'+parameter,
        success: function(response) {
          if (response.error_code) {
            alert(response.message);
          } else {
            $liId = localStorage.getItem('folder-selected-id');
            $('#'+$liId+' .select').html(response.subject.name);
            $('#'+$liId+' .select').addClass('checked');
            $('#'+$liId+' .cancel').removeClass('hidden');
            $('#'+$liId+' .label').html('переместить в');
            $('#set_folder_'+$liId).val(response.subject.id);
            $('.cancel_all').removeClass('hidden');
            on_closePopup('popup_set_subject');
            $("#addSubjectForm input[type=text]").val('');
            $("#addSubjectForm [value='0']").attr("selected", "selected");
            //$('#btnAddSubject').prop('disabled',true);
          }
        }
      });
      return false;
    });
  
    $('html').click(function(e) {
      if ($(e.target).closest('.popup_add').length == 0) {
        $('.popup_add').css('display', 'none');
      }
      if ($(e.target).closest('.popup_alert').length == 0) {
        $('.popup_alert').css('display', 'none');
      }
    });
  
    $(this).keydown(function(eventObject){
      if (eventObject.which == 27) {
        $('.popup_add').css('display', 'none');
        $('.popup_alert').css('display', 'none');
      }
    });
  
  
  });
  
  function getProps(toObj, tcSplit) {if (!tcSplit) tcSplit = '\n'; var lcRet = ''; var lcTab = '    '; for (var i in toObj) lcRet += lcTab + i + " : " + toObj[i] + tcSplit; lcRet = '{' + tcSplit + lcRet + '}'; return lcRet;}
  
  var filterDataList = new Array();
  
  $().ready(function() {
    $('#filterKey').focus();
  });
  
  function on_changeSubjectFilter() {
    var goToPage = rootUrl+'/'+document.getElementById('ddlUniversity').value+'/';
    window.location = goToPage;
  }
  
  function on_changeFilesFilter() {
    goToPage = rootUrl+'/'+document.getElementById('ddlUniversity').value+'/'+document.getElementById('ddlSubject').value+'/';
    window.location = goToPage;
  }
  
  function on_changeUsersFilter() {
    var goToPage  = rootUrl+'/users/';
    var filterSet = $('#txtSearchKey').val() ? 'filter:'+$('#txtSearchKey').val()+'/' : '';
  
    if (document.getElementById('ddlUniversity').value * 1) {
      goToPage = rootUrl+'/users/university:'+document.getElementById('ddlUniversity').value+'/';
    } 
  
    window.location = goToPage + filterSet;
  
    return false;
  }
  
  function on_changeSearchFilter() {
    var goToPage  = rootUrl+'/search/';
    var filterSet = $('#txtSearchKey').val() ? '?q='+$('#txtSearchKey').val() : '';
  
    if (document.getElementById('ddlUniversity').value != 'all-vuz') {
      goToPage = rootUrl+'/search/'+document.getElementById('ddlUniversity').value+'/';
    } 
  
    window.location = goToPage + filterSet;
  
    return false;
  }
  
  function on_columnFilterKey(filterKey, controlID, keyCode) {
    if (keyCode == 27) {
      $('.popup_add').css('display', 'none');
      return false;
    }
  
    var resultFilter = new Array();
    var escapedSearchText = filterKey.replace(/[-[\]{}()*+?.,\\^$|#\s]/g, "\\$&");
    var regex = new RegExp(escapedSearchText, 'i');
  
    if (controlID == undefined) var control = '.cell_list';
    else var control = '#'+controlID;
  
    // Получаем список элементов, если он еще не задан
    if (filterDataList[control] === undefined) {
      getFilterList(control, controlID);
    }
  
    // Получаем отфильтрованный список
    var index = 0;
    for (i=0; i<filterDataList[control].length; i++) {
      fields = filterDataList[control][i]['fields'];
      result = new Array();
      index2 = 0;
      for (j=0; j<fields.length; j++) {
        //alert(getProps(fields)); return false;
        itemField = fields[j];
        startposName = itemField['name'].search(regex);
        startposAbbr = itemField['abbr'].search(regex);
        itemField['name_show'] = (startposName > -1) ? itemField['name'].substring(0, startposName) + '<pre class="search_selected">' + itemField['name'].substring(startposName, startposName+escapedSearchText.length ) + '</pre>' + itemField['name'].substring(startposName+escapedSearchText.length) : itemField['name'];
        itemField['abbr_show'] = (startposAbbr > -1) ? itemField['abbr'].substring(0, startposAbbr) + '<pre class="search_selected">' + itemField['abbr'].substring(startposAbbr, startposAbbr+escapedSearchText.length ) + '</pre>' + itemField['abbr'].substring(startposAbbr+escapedSearchText.length) : itemField['abbr'];
        if (startposName > -1 || startposAbbr > -1) {
          result[index2] = itemField;
          index2++;
        }
      }
  
      if (result.length > 0) {
        setResult = new Array();
        setResult['title'] 		= filterDataList[control][i]['title'];
        setResult['parent_id'] 	= filterDataList[control][i]['parent_id'];
        setResult['fields'] 	= result;
        resultFilter[index] 	= setResult;
        index++;
      }
    }
  
    // Очищаем список
    $(control).html('');
  
    // Выводим результат
    for (i=0; i<resultFilter.length; i++) {
      fields	 = resultFilter[i];
      $divCell = $('<div>');
      $divCell.addClass('cell');
      $divCell.append('<span class="title">'+fields['title']+'</span>');
  
      for (j=0; j<fields['fields'].length; j++) {
        itemField = fields['fields'][j];
        $divRow = $('<div>'); 				$divRow.addClass('data');
        $divRow.append('<span class="abbr">'+itemField['abbr_show']+'</span>');
        $divRow.append('<span class="name"><a href="'+itemField['url']+'">'+itemField['name_show']+'</a>&nbsp;&nbsp;<span class="count">'+itemField['count']+'</span></span>');
        $divCell.append($divRow);
  
      }
  
      $('#'+fields['parent_id']).append($divCell);
    }
  }
  
  function getFilterList(control, controlID) {
    filterDataList[control] = new Array();
    $cellList = $(control+' .cell');
  
    for (i=0; i<$cellList.length; i++) {
      $cell = $cellList.eq(i);
      $rows = $cell.find('div');
  
      $item = new Array();
      $item['title']  	= $cell.find('.title').text();
      $item['fields'] 	= new Array();
  
      if (controlID == undefined) $item['parent_id']  = $cell.parent().attr('id');
      else $item['parent_id']  = controlID;
  
      for (j=0; j<$rows.length; j++) {
        $rowData = $rows.eq(j);
        $field   = new Array();
        $field['abbr']  = $rowData.find('.abbr').text();
        $field['name']  = $rowData.find('.name a').text();
        $field['url']   = $rowData.find('.name a').attr('href');
        $field['count'] = $rowData.find('.count').text();
  
        $item['fields'][j] = $field;
      }
  
      filterDataList[control][i] = $item;
    }
  
    //alert(getProps(filterDataList[control]));
  }
  
  var regUniversity = /([a-zA-Z0-9_-]+)/;
  var currentPath   = document.location.pathname;
  
  if (regUniversity.test(currentPath)) {
    var currentUniversity = regUniversity.exec(currentPath)[1];
    $("#ddlUniversity [value='"+currentUniversity+"']").attr("selected", "selected");
  }
  
  $(document).ready(function() {
    //$("#ddlUniversity").chosen({});
  
    $('.title_holder a').click(function() {		//$('#subject_select_sort a').live('click', function() {
      listId = '#list_'+$(this).attr('href').substr(1);
  
      if ($(listId).html().length > 13 && $(listId).hasClass('hidden')) {
        $(listId).slideDown();
        $(listId).removeClass('hidden');
        $(this).parent().prev().addClass('open');
      } else if ($(listId).html().length > 13) {
        $(listId).slideUp();
        $(listId).addClass('hidden');
        $(this).parent().prev().removeClass('open');
      }
      else {
        $.ajax({
          url:rootUrl+'/api/files.json.php', 
          type:'GET',
          data:'method=getSearchResult&parent_id='+$(this).attr('href').substr(1)+'&key='+$('#txtSearchKey').val()+'&university='+$('#ddlUniversity').val(),
          success: function(response) {
            for (i=0; i<response.result.length; i++) {
              $subject 	= response.result[i];
              $ul			= $('<ul>');
              $(listId).append('<h2>'+$subject.name+'</h2>');
  
              for (j=0; j<$subject.users.length; j++) {
                $user 	= $subject.users[j];
                $li 	= $('<li>');
                $li.append('<a class="user_info" href="'+$user.url+'" target="_blank">'+$user.login+'</a>');
  
                for (k=0; k<$user.files.length; k++) {
                  $file = $user.files[k];
                  $li.append('<div class="path"><span></span>'+$file.path+'</div>');
                  $li.append('<div class="filename '+$file.file_type+'">'+$file.file+'</div>');
                }
  
                $ul.append($li);
              }
  
              $(listId).append($ul);
            }
  
            $(listId).slideDown();
            $(listId).removeClass('hidden');
            $(listId).parent().find('.title_holder a').addClass('open');
          }
        });
      }
  
      return false;
    });
  
  
    // --- Проверка статуса перед скачиванием файла
    $('.link_download').live('click', function() {
      fileId = $(this).attr('href').substr(1);
  
      $.ajax({
        url:rootUrl+'/api/files.json.php', 
        type:'GET',
        data:'method=checkDownloadStatus&file_id='+fileId,
        success: function(response) {
          if (response.error_code) {
            alert(response.message);
          } else {
            //alert(response.message);
            window.location = response.download_url;
          }
        }
      });
  
      return false;
    });
  });
  
  
  $.fn.tabs = function() {
    var selector = this;
    this.each(function() {
      var obj = $(this);
      $(obj.attr('href')).hide();
      $(obj).click(function() {
        $(selector).removeClass('selected');
        $(selector).each(function(i, element) {
          $($(element).attr('href')).hide();
        });
        $(this).addClass('selected');
        $($(this).attr('href')).fadeIn();
        return false;
      });
    });
    $(this).show();
    $(this).first().click();
  };
