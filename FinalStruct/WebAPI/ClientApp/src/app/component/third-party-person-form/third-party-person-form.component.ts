import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ThirdPartyPerson } from 'src/app/model/third-party-person';
import { ThirdPartyPersonService } from 'src/app/service/third-party-person.service';

@Component({
  selector: 'app-third-party-person-form',
  templateUrl: './third-party-person-form.component.html',
  styleUrls: ['./third-party-person-form.component.css']
})
export class ThirdPartyPersonFormComponent implements OnInit {

  tpperson: ThirdPartyPerson;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private tppService: ThirdPartyPersonService) {
      this.tpperson = new ThirdPartyPerson();
    }

  ngOnInit() {
  }

  onSubmit() {
    this.tppService.save(this.tpperson).subscribe(result => this.gotoThirdPartyPersonList());
  }

  gotoThirdPartyPersonList() {
    this.router.navigate(['tpperson']);
  }

}
