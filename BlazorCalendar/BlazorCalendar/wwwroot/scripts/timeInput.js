export function timeInputsInit() {
    const inputs = document.querySelectorAll('input[kind="time"]');

    for (const inpt of inputs) {
        inpt.value = (inpt.value || '').length < 2 ? `0${inpt.value}` : inpt.value;
        inpt.onchange = function () {
            let val = inpt.value || '';

            if (val.length < 2) {
                inpt.value = `0${val}`;
            }

            if (val.length > 2) {
                inpt.value = inpt.value.substring(0, 2);
            }
        };

        inpt.onkeyup = function () {
            let val = inpt.value || '';
            const subKind = inpt.getAttribute('sub-kind');

            if (val.length > 2) {
                inpt.value = inpt.value.substring(0, 2);
            }

            let valNumber = Number(val);
            switch (subKind) {
                case 'hours': {
                    if (valNumber > 23) {
                        inpt.value = '23';
                    }
                    break;
                }
                case 'minutes': {
                    if (valNumber > 59) {
                        inpt.value = '59';
                    }
                    break;
                }
            }
        };
    }
}
export function getClientTimezoneOffset() {
    console.log("getClientTimezoneOffset");
    return new Date().getTimezoneOffset();
}