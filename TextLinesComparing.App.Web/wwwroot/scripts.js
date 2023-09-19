function displaySelectedFile(input_id) {
    let input = document.getElementById(input_id);

    input.onchange = e => { 
        let file = e.target.files[0]; 

        let reader = new FileReader();
        reader.readAsText(file,'UTF-8');

        reader.onload = readerEvent => {
            let content = readerEvent.target.result;
            console.log(content);
        }
    }
}
