Feature: ReqresIn
	ReqresIn api testing senaryoları içerir.

Scenario: ListUsers
	* 2 numaralı sayfadaki user listesini döner

Scenario: SingleUser
	* 2 numaralı user bilgisini döner

Scenario: SingleUserNotFound
	* 23 numaralı user olmadığı için 404 döner

Scenario: ListResource
	* unknown ListResource

Scenario: SingleResource
	* 2 unknown SingleResource

Scenario: SingleResourceNotFound
	* 23 unknown SingleResourceNotFound

Scenario: Create
	* 'Yunus Emre' ve 'QA Engineer' yeni user oluşturulur

Scenario: UpdatePut
	* 2 numaralı user bilgisi put ile güncellenir

Scenario: UpdatePatch
	* 2 numaralı user bilgisi patch ile güncellenir

Scenario: Delete
	* 2 numaralı user bilgisi silinir

Scenario: RegisterSuccessful
	* 'eve.holt@reqres.in' ve 'pistol' register edilir

Scenario: RegisterUnsuccessful
	* 'sydney@fife' register edilemedi

Scenario: LoginSuccessful
	* 'eve.holt@reqres.in' ve 'cityslicka' login olunur

Scenario: LoginUnsuccessful
	* 'peter@klaven' login olunamadı

Scenario: DelayedResponse
	* 3 DelayedResponse