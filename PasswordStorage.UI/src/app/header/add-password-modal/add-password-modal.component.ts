import {Component, inject, OnInit} from '@angular/core';
import {ModalService} from "../../../services/modal.service";
import {Observable, Subscriber} from "rxjs";
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from "@angular/forms";
import {UserPasswordService} from "../../../services/user-password.service";

@Component({
  standalone: true,
  imports: [ReactiveFormsModule],
  selector: 'add-password-modal',
  templateUrl: 'add-password-modal.component.html'
})

export class AddPasswordModalComponent implements OnInit {
  private modalsService = inject(ModalService);
  private userPasswordService = inject(UserPasswordService);
  private subscriber = new  Subscriber<boolean>();
  private observable = new Observable<boolean>(sub => {
    this.subscriber = sub;
    this.modalsService.addSubscriber("AddPassword", this.subscriber);
  });

  ngOnInit(): void {
    this.observable.subscribe(isOpen => isOpen ? this.popup() : this.close());
  }

  isOpen = false;
  _isEmail = true;
  get isEmail() : boolean {
    return this._isEmail;
  }

  set isEmail(isEmail: boolean) {
    this._isEmail = isEmail;
    const controls = this.addPasswordForm.controls;

    if (isEmail)
      controls.website.setValue("");
    else controls.email.setValue("");
  }

  addPasswordForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    website: new FormControl('', [Validators.required, Validators.minLength(1)]),
    password: new FormControl('', [Validators.required, Validators.minLength(8)])
  })

  async onSubmit() {
    const errors = this.getErrors();
    if (errors.length > 0)
    {
      alert(errors.join('\n'));
      return;
    }

    const formValues = this.addPasswordForm.value;
    const email = <string>formValues.email;
    const website = <string>formValues.website;
    const password = <string>formValues.password;

    const addPasswordPromise = this._isEmail
      ? this.userPasswordService.addEmailPassword(email, password)
      : this.userPasswordService.addWebsitePassword(website, password);
    await addPasswordPromise.catch(this.catchFallback);
    await this.userPasswordService.refresh().catch(this.catchFallback);
    this.close();
  }

  popup() {
    this.isOpen = true;
  }

  close() {
    const controls = this.addPasswordForm.controls;
    controls.email.setValue("");
    controls.website.setValue("");
    controls.password.setValue("");
    this.isOpen = false;
  }

  private getErrors(): string[] {
    const controls = this.addPasswordForm.controls;
    const errors = [];
    if (controls.email.hasError("email"))
      errors.push("Почта не валидна");
    if (this._isEmail && controls.email.hasError("required"))
      errors.push(`Поле "Почта" пустое`);
    if (!this._isEmail && controls.website.hasError("required"))
      errors.push(`Поле "Сайт" пустое`);
    if (controls.password.hasError("required"))
      errors.push(`Поле "Пароль" пустое`);
    if (controls.password.hasError("minlength"))
      errors.push("Минимальная длина пароля - 8 символов");
    return errors;
  }

  private catchFallback = (err: any) => {
    alert("Произошла ошибка");
    console.log(err);
  };
}
