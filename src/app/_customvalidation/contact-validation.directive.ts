import { Directive } from '@angular/core';
import { AbstractControl,Validator,NG_VALIDATORS, ValidationErrors } from '@angular/forms';

@Directive({
  selector: '[appContactValidation]',
  providers: [
    {
      provide: NG_VALIDATORS,
      useExisting: ContactValidationDirective,
      multi: true,
    },
  ],
})
export class ContactValidationDirective implements Validator {
  validate(control: AbstractControl): { [key: string]: any } | null {
    if (control.value && control.value.length != 10) {
      return { 'phoneNumberInvalid': true };
    }
    return null;
  }
}
