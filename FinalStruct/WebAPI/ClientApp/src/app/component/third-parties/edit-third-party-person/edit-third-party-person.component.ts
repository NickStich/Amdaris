import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ThirdPartyPerson } from 'src/app/model/thirdPartyPerson/third-party-person';
import { ThirdPartyPersonService } from 'src/app/service/thirdPartiesService/third-party-person.service';

@Component({
  selector: 'app-edit-third-party-person',
  templateUrl: './edit-third-party-person.component.html',
  styleUrls: ['./edit-third-party-person.component.css']
})
export class EditThirdPartyPersonComponent implements OnInit {

  thirdPartyPerson: ThirdPartyPerson;

  types: number[] = [1, 2];

  constructor(private route: ActivatedRoute,
    private router: Router,
    private tppService: ThirdPartyPersonService) {
      this.thirdPartyPerson = new ThirdPartyPerson();
    }

  ngOnInit() {
    let id: number;
    id = parseInt(this.route.snapshot.paramMap.get('id'), 10);
    this.tppService.getById(id).subscribe(data => {
      this.thirdPartyPerson = data;
    });
  }

  onSubmit() {
    this.tppService.update(this.thirdPartyPerson.id, this.thirdPartyPerson).subscribe(result => this.gotoThirdPartyPersonList());
  }

  gotoThirdPartyPersonList() {
    this.router.navigate(['tpperson']);
  }

}
