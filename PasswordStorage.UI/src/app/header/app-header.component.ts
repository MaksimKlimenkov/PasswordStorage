import {Component} from '@angular/core';
import {Constants} from "../../constants";
import {SearchBarComponent} from "./search-bar/search-bar.component";
import {AddPasswordButtonComponent} from "./add-password-button/add-password-button.component";

@Component({
  standalone: true,
  selector: 'app-header',
  templateUrl: 'app-header.component.html',
  imports: [
    SearchBarComponent,
    AddPasswordButtonComponent
  ],
  styleUrl: 'app-header.component.css'
})

export class AppHeaderComponent {
  title = Constants.AppTitle
}
