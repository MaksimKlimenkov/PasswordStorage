import {Component, inject} from '@angular/core';
import {UserPasswordService} from "../../../services/user-password.service";
import {FormsModule} from "@angular/forms";

@Component({
  standalone: true,
  selector: 'search-bar',
  imports: [
    FormsModule
  ],
  templateUrl: 'search-bar.component.html',
  styleUrl: 'search-bar.component.css'
})

export class SearchBarComponent {
  private userPasswordService = inject(UserPasswordService);
  searchQuery: string = "";


  change(event: any){
    this.searchQuery = event.target.value;
    this.userPasswordService.search(this.searchQuery);
  }
}
