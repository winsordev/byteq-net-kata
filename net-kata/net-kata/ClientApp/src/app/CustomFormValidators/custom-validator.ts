import { AbstractControl, FormControl } from '@angular/forms';

export class CustomValidator {
    static ValidateEmailWhenNotBlank(control: AbstractControl): { [key: string]: boolean } | null {
        if (control.value !== '') {
            const eMailPattern = /^[a-zA-Z0-9.-_]{1,}@[a-zA-Z .-]{2,}[.]{1}[a-zA-Z]{2,}$/;
            const eMailIsValid = eMailPattern.test(control.value);

            if (eMailIsValid) {
                return null;
            } else {
                return { 'Email is not valid.': true };
            }
        }

        return null;
    }

    static emailValidator(control: AbstractControl): { [key: string]: boolean } {
        //initialize email pattern 
        var EMAIL_REGEXP = /^(?=.{1,64}@)(?:("[^"\\]*(?:\\.[^"\\]*)*"@)|((?:[0-9a-zA-Z](?:\.(?!\.)|[-!#\$%&'\*\+\/=\?\^`\{\}\|~\w])*)?[0-9a-zA-Z]@))(?=.{1,255}$)(?:(\[(?:\d{1,3}\.){3}\d{1,3}\])|((?:(?=.{1,63}\.)[0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-z0-9A-Z][\-a-z0-9A-Z]{0,22}[a-z0-9A-Z])|((?=.{1,63}$)[0-9a-zA-Z][-\w]*))$/;
        //check the email string
        if (control.value != "" && !EMAIL_REGEXP.test(control.value)) {
            return { 'emailInvalid': true };
        }
        return { 'emailInvalid': false};
    }
}