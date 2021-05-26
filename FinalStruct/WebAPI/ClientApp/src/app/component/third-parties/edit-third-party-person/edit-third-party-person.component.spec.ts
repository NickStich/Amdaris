import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EditThirdPartyPersonComponent } from './edit-third-party-person.component';

describe('EditThirdPartyPersonComponent', () => {
  let component: EditThirdPartyPersonComponent;
  let fixture: ComponentFixture<EditThirdPartyPersonComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EditThirdPartyPersonComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EditThirdPartyPersonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
