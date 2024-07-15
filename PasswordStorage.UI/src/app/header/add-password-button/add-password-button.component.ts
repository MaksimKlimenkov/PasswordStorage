import {Component, inject} from '@angular/core';
import {ModalService} from "../../../services/modal.service";
import {AddPasswordModalComponent} from "../add-password-modal/add-password-modal.component";

@Component({
  standalone: true,
  selector: 'add-password-button',
  imports: [
    AddPasswordModalComponent
  ],
  templateUrl: 'add-password-button.component.html',
  styleUrl: 'add-password-button.component.css'
})

export class AddPasswordButtonComponent {
  private modalService = inject(ModalService);
  onClick() {
    const subscriber = this.modalService.getSubscriber("AddPassword");
    subscriber.next(true);
  }
}
