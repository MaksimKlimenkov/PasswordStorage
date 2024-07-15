import {Component, EventEmitter, inject, OnInit} from '@angular/core';
import {UserPasswordService} from "../../services/user-password.service";
import {UserPassword} from "../../types/user-password";

@Component({
  standalone: true,
  selector: 'password-list',
  templateUrl: 'password-list.component.html',
  styleUrl: 'password-list.component.css'
})
export class PasswordListComponent implements OnInit {
  private userPasswordService = inject(UserPasswordService);
  passwords: UserPassword[] = []

  ngOnInit(): void {
    this.userPasswordService.userPasswordsObserver.subscribe(
      passwords => this.passwords = passwords);
    this.userPasswordService.search();
  }
}
