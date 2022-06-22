function dragStart(ev){
    ev.dataTransfer.effectAllowed='link';
    ev.dataTransfer.setData("Text", ev.target.getAttribute('id'));
    ev.dataTransfer.setDragImage(ev.target,0,0);
    return true;
}


function dragEnter(ev){
    // var idelt = ev.dataTransfer.getData("Text");
    shish = ev.target.getAttribute('id');
    return true;
}

function dragOver(ev){
    // var idelt = ev.dataTransfer.getData("Text");
    // var id = ev.target.getAttribute('id');
    return false;
}

function dragEnd(ev){
    ev.dataTransfer.clearData("Text");
    return true
}

function dragDrop(ev){
    var idelt = ev.dataTransfer.getData("Text");
    var id = ev.target.getAttribute('id');
    if (id == 'source'){
        alert("челл, бери...");
    }
    else if (idelt != 'firstDragElement' || id != 'target1' && id != 'source'){
        ev.target.appendChild(document.getElementById(idelt));
        ev.stopPropagation();
    }
    else{
        alert("челл, ты видел что это за сайт...");
    }
    
    return false;
}